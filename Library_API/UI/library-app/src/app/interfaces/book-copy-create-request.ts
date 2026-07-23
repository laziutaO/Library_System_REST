export interface BookCopyRequest {
    title: string,
    isbn: string,
    publisher: string,
    year: number,
    pagesCount: number,
    description: string,
    coverImageUrl: string,
    authorNames: string[],
    genreNames: string[],
    status: string,
    libraryNames: string[]
}
