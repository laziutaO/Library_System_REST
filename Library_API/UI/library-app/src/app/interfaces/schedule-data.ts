export interface ScheduleData {
    id: string,
    dayOfWeek: string,
    openTime?: string,
    closeTime?: string,
    isClosed: boolean
}

export type DayOfWeek = 
    | "Monday" 
    | "Tuesday"
    | "Wednesday"
    | "Thursday" 
    | "Friday"
    | "Saturday"
    | "Sunday"

