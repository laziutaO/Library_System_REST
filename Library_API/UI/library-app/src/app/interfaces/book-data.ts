import { LibraryData } from "./library-data"

export interface BookData {
    id: string,
    title: string,
    isbn: string,
    publisher: string,
    year: number,
    pagesCount: number,
    description: string,
    coverImageUrl: string,
    fileUrl?: string,
    bookAccessType?: number
    authorNames?: string[],
    genreNames?: string[]
    libraries?: LibraryData[]
}
