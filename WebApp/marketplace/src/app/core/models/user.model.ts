import { Offer } from "./offer.model";

export class User {
    id: number;
    username: string;
    offers?: Offer[];
}