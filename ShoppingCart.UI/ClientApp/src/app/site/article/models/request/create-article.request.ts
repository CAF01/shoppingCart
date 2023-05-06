export interface CreateArticleRequest {
    code: string;
    description: string;
    price: number;
    image: string;
    stock: number;
    idStore: number;
}