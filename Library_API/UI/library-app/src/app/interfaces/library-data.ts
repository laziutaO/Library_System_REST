import { ScheduleData } from "./schedule-data"
export interface LibraryData {
    id: string,
    name: string,
    description: string,
    coverImageUrl: string,
    address: string,
    phone: string,
    email: string,
    studyRooms: number,
    computers: number,
    schedule: ScheduleData[]
}
