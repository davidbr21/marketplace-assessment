export class Offer {
    categoryId: number;
    categoryName: string;
    description: string;
    location: string;
    pictureUrl: string;
    title: string;
    userId: string;
    userName: string;
    publishedOn: Date;
}

export class PostOfferDTO {
    categoryId: number;
    description: string;
    location: string;
    pictureUrl: string;
    title: string;
    userId: string;
}
