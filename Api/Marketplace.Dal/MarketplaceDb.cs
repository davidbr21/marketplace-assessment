// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Marketplace.Core.DTOs;
using Marketplace.Core.Model;
using Marketplace.Core.Results;
using Microsoft.Data.Sqlite;

namespace Marketplace.Dal
{
    internal class MarketplaceDb : IMarketplaceDb, IDisposable
    {
        private readonly SqliteConnection _connection;

        public MarketplaceDb()
        {
            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @".."));
            _connection = new SqliteConnection($@"Data Source={path}\Marketplace.Dal\marketplace.db");
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public async Task<User[]> GetUsersAsync()
        {
            await using var command = new SqliteCommand(
                "SELECT U.Id, U.Username, COUNT(O.Id) AS Offers\r\n" +
                "FROM User U LEFT JOIN Offer O ON U.Id = O.UserId\r\n" +
                "GROUP BY U.Id, U.Username;",
                _connection);

            try
            {
                await using var reader = await command.ExecuteReaderAsync();


                var results = new List<User>();

                while (await reader.ReadAsync())
                {
                    var user = new User
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Username = reader.GetString(reader.GetOrdinal("Username"))
                    };

                    results.Add(user);
                }

                return results.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> InsertUserAsync(InsertUserDTO user)
        {
            await using var command = new SqliteCommand(
                "INSERT INTO User \r\n" +
                "(Username) VALUES (@username) ",
                _connection);

            try
            {
                command.Parameters.AddWithValue("@username", user.Username);

                await command.ExecuteNonQueryAsync();

                var selectLastIdQuery = "SELECT last_insert_rowid()";
                var selectLastIdCommand = new SqliteCommand(selectLastIdQuery, _connection);
                var lastInsertedId = await selectLastIdCommand.ExecuteScalarAsync();

                return Convert.ToInt32(lastInsertedId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            await using var selectUserCommand = new SqliteCommand(
                "SELECT Id, Username FROM User WHERE Username = @Username",
                _connection);

            selectUserCommand.Parameters.AddWithValue("@Username", username);

            try
            {
                await using var reader = await selectUserCommand.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var user = new User
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Username = reader.GetString(reader.GetOrdinal("Username"))
                    };

                    return user;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<CategoryListResult[]> GetCategoriesAsync()
        {
            await using var command = new SqliteCommand(
                "SELECT Id, Name FROM Category",
                _connection) ;
            try
            {
                await using var reader = await command.ExecuteReaderAsync();
                var results = new List<CategoryListResult>();

                while (await reader.ReadAsync())
                {
                    var cat = new CategoryListResult
                    {
                        Id = reader.GetByte("Id"),
                        Name = reader.GetString("Name")
                    };
                    results.Add(cat);
                }

                return results.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Offer> InsertOfferAsync(InsertOfferDTO offer)
        {
            await using var command = new SqliteCommand(
                "INSERT INTO Offer \r\n" +
                "(Id, CategoryId, Description, Location, PictureUrl, PublishedOn, Title, UserId)  \r\n" +
                "VALUES (@Id, @CategoryId, @Description, @Location, @PictureUrl, @PublishedOn, @Title, @UserId) ",
                _connection);

            try
            {
                Guid guid = Guid.NewGuid();

                command.Parameters.AddWithValue("@Id", guid);
                command.Parameters.AddWithValue("@CategoryId", offer.CategoryId);
                command.Parameters.AddWithValue("@Description", offer.Description);
                command.Parameters.AddWithValue("@Location", offer.Location);
                command.Parameters.AddWithValue("@PictureUrl", offer.PictureUrl);
                command.Parameters.AddWithValue("@PublishedOn", DateTime.Now);
                command.Parameters.AddWithValue("@Title", offer.Title);
                command.Parameters.AddWithValue("@UserId", offer.UserId);

                await command.ExecuteNonQueryAsync();

                await using var selectOfferCommand = new SqliteCommand(
                    "SELECT * FROM Offer WHERE Id = @Id",
                    _connection);

                selectOfferCommand.Parameters.AddWithValue("@Id", guid);

                await using var reader = await selectOfferCommand.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var offerReturned = new Offer
                    {
                        Id = reader.GetGuid("Id"),
                        CategoryId = reader.GetByte("CategoryId"),
                        Description = reader.GetString("Description"),
                        Location = reader.GetString("Location"),
                        PictureUrl = reader.GetString("PictureUrl"),
                        PublishedOn = reader.GetDateTime("PublishedOn"),
                        Title = reader.GetString("Title"),
                        UserId = reader.GetInt32("UserId"),
                    };
                    return offerReturned;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<PagedResult<OfferListResult>> GetOffersAsync(int pageIndex, int pageSize)
        {
            try
            {
                await using var command = new SqliteCommand(
                    $"SELECT O.CategoryId, C.Name AS CategoryName, O.Description, O.Location, O.PictureUrl, O.PublishedOn, O.Title, U.Username AS UserName " +
                                    $"FROM Offer O " +
                                    $"INNER JOIN Category C ON O.CategoryId = C.Id " +
                                    $"INNER JOIN User U ON O.UserId = U.Id " +
                                    $"ORDER BY O.PublishedOn DESC " +
                                    $"LIMIT {pageSize} OFFSET {pageIndex * pageSize}",
                    _connection);

                await using var countOffersCommand = new SqliteCommand("SELECT COUNT(Id) FROM Offer", _connection);
                var totalOffers = Convert.ToInt32(await countOffersCommand.ExecuteScalarAsync());

                await using var reader = await command.ExecuteReaderAsync();

                var results = new List<OfferListResult>();

                while (await reader.ReadAsync())
                {
                    var offerReturned = new OfferListResult
                    {
                        CategoryId = reader.GetByte("CategoryId"),
                        CategoryName = reader.GetString("CategoryName"),
                        Description = reader.GetString("Description"),
                        Location = reader.GetString("Location"),
                        PictureUrl = reader.GetString("PictureUrl"),
                        PublishedOn = reader.GetDateTime("PublishedOn"),
                        Title = reader.GetString("Title"),
                        UserName = reader.GetString("UserName")
                    };
                    results.Add(offerReturned);
                }

                return new PagedResult<OfferListResult>
                {
                    Items = results,
                    TotalItems = totalOffers,
                    TotalPages = (int)Math.Ceiling((double)totalOffers / pageSize),
                    CurrentPage = pageIndex
            }; ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
