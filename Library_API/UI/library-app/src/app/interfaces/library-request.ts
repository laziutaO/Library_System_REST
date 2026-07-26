export interface LibraryRequest {
    name: string,
    description: string,
    coverImageUrl: string,
    address: string,
    phone: string,
    email: string,
    studyRooms: number,
    computers: number,
    schedule: daySchedule[]
}

type daySchedule =  {    
    dayOfWeek: string,
    openTime: string | null,
    closeTime: string | null,
    isClosed: boolean
}