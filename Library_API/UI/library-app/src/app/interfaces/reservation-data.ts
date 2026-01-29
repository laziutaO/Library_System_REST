export interface ReservationData {
    id: string,
    libraryId: string,
    userId: string, 
    bookId: string,
    reserveDate: string,
    expiresAt: string,
    isClosed: boolean
}
