export interface EbookCreateRequest {
    title: string,
    isbn: string,
    publisher: string,
    year: number,
    pagesCount: number,
    description: string,
    coverImageUrl: string,
    fileUrl: string,
    bookAccessType: string,
    authorNames: string[],
    genreNames: string[],
}
