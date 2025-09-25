using Bogus;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public static class LibraryMapper
    {
        public static LibraryRequest LibraryToGetDto(this Library library)
        {
            return new(
                library.Id.ToString(),
                library.Description,
                library.CoverImageUrl,
                library.Name,
                library.Address,
                library.Phone,
                library.Email,
                library.StudyRooms,
                library.Computers,
                library.Schedules.Select(sc => sc.ScheduleToGetDto()).ToList());
        }


        public static void UpdateDtoToLibrary(this LibraryUpdateRequest request, Library library)
        {
            library.Name = request.name;
            library.Address = request.address;
            library.Phone = request.phone;
            library.Description = request.description;
            library.StudyRooms = request.studyRooms;
            library.Computers = request.computers;
            library.Email = request.email;
            library.CoverImageUrl = request.coverImageUrl;
            library.Schedules.Clear();
            foreach(var day in request.schedule)
            {
                library.Schedules.Add(day.UpdateDtoToSchedule(library.Id));
            }
        }

        public static Library CreateDtoToLibrary(this LibraryCreateRequest request)
        {
            return new Library
            {
                Id = Guid.NewGuid(),
                Name = request.name,
                Address = request.address,
                Phone = request.phone,
                Description = request.description,
                Email = request.email,
                StudyRooms = request.studyRooms,
                Computers = request.computers,
                CoverImageUrl = request.coverImageUrl,
                Schedules = request.schedule.Select(s => s.CreateDtoToSchedule()).ToList()
            };
        }

        public static LibraryScheduleGetRequest ScheduleToGetDto(this LibrarySchedule schedule) 
        {
            return new LibraryScheduleGetRequest(
                schedule.Id.ToString(),
                schedule.DayOfWeek.ToString(),
                schedule.OpenTime.ToString()!,
                schedule.CloseTime.ToString()!,
                schedule.IsClosed);
        }

        public static LibrarySchedule UpdateDtoToSchedule(this LibraryScheduleUpdateRequest request, Guid libraryid)
        {
            return new LibrarySchedule()
            {
                LibraryId = libraryid,
                DayOfWeek = Enum.Parse<DayOfWeek>(request.dayOfWeek, true),
                OpenTime = string.IsNullOrEmpty(request.openTime) ? null : TimeSpan.Parse(request.openTime),
                CloseTime = string.IsNullOrEmpty(request.closeTime) ? null : TimeSpan.Parse(request.closeTime),
                IsClosed = request.isClosed
            };
        }

        public static LibrarySchedule CreateDtoToSchedule(this LibraryScheduleCreateRequest request)
        {
            return new LibrarySchedule()
            {
                DayOfWeek = Enum.Parse<DayOfWeek>(request.dayOfWeek, true),
                OpenTime = string.IsNullOrEmpty(request.openTime) ? null : TimeSpan.Parse(request.openTime),
                CloseTime = string.IsNullOrEmpty(request.closeTime) ? null : TimeSpan.Parse(request.closeTime),
                IsClosed = request.isClosed
            };
        }


    }
}
