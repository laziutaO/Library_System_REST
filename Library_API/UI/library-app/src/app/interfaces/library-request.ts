import {ScheduleRequest} from './schedule-request';

export interface LibraryRequest {
    name: string,
    description: string,
    coverImageUrl: string,
    address: string,
    phone: string,
    email: string,
    studyRooms: number,
    computers: number,
    schedule: ScheduleRequest[]
}
