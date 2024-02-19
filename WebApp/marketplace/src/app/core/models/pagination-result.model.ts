export class PaginationResult<T> {
    items: Array<T>;
    totalItems: number;
    totalPages: number;
    currentPage: number;
}