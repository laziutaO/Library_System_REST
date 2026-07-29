import { Component, inject, OnInit, signal, computed, effect } from '@angular/core';
import { LibrariesService } from '../../services/libraries-service';
import { LibraryRequest } from '../../interfaces/library-request';
import { ScheduleRequest } from '../../interfaces/schedule-request';
import { ActivatedRoute } from '@angular/router';
import { LibraryData } from '../../interfaces/library-data';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-library-form',
  imports: [ReactiveFormsModule],
  templateUrl: './edit-library-form.html',
  styleUrl: './edit-library-form.css',
})
export class EditLibraryForm {
  fb = inject(FormBuilder);
  libraryService = inject(LibrariesService);
  route = inject(ActivatedRoute)
  libraryId: string
  libraryData!: LibraryData

  constructor() {
    this.libraryId = this.route.snapshot.paramMap.get('id')!;
  }
  days = [
    'Monday',
    'Tuesday',
    'Wednesday',
    'Thursday',
    'Friday',
    'Saturday',
    'Sunday'
  ];
  editLibraryForm = this.fb.group({
    description: ['', Validators.required],
    coverImageUrl: ['', Validators.required],
    name: ['', Validators.required],
    address: ['', Validators.required],
    phone: ['', Validators.required],
    email: ['', Validators.required],
    studyRooms: [0, Validators.required],
    computers: [0, Validators.required],
    schedule: this.fb.array(this.days.map(day =>
      this.fb.group({
        dayOfWeek: [day],
        openTime: [''],
        closeTime: [''],
        isClosed: [false]
      })))
  });
  ngOnInit() {
    this.libraryService.getLibraryById(this.libraryId).subscribe(lib => {
      this.libraryData = lib;
      this.editLibraryForm.patchValue({
        description: lib.description,
        coverImageUrl: lib.coverImageUrl,
        name: lib.name,
        address: lib.address,
        phone: lib.phone,
        email: lib.email,
        studyRooms: lib.studyRooms,
        computers: lib.computers,
        schedule: lib.schedule,
      });
    })};
    onSubmit() {
      const request: LibraryRequest = {
        description: this.editLibraryForm.value.description!,
        coverImageUrl: this.editLibraryForm.value.coverImageUrl!,
        name: this.editLibraryForm.value.name!,
        address: this.editLibraryForm.value.address!,
        phone: this.editLibraryForm.value.phone!,
        email: this.editLibraryForm.value.email!,
        studyRooms: this.editLibraryForm.value.studyRooms!,
        computers: this.editLibraryForm.value.computers!,
        schedule: this.editLibraryForm.value.schedule! as ScheduleRequest[],
      };
      this.libraryService.updateLibrary(this.libraryId, request).subscribe();
    }
  }
