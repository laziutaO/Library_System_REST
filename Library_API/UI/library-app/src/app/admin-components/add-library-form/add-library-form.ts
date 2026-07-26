import { Component, inject, OnInit, signal, computed, effect } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { LibrariesService } from '../../services/libraries-service';
import { LibraryRequest } from '../../interfaces/library-request';

@Component({
  selector: 'app-add-library-form',
  imports: [
    ReactiveFormsModule],
  templateUrl: './add-library-form.html',
  styleUrl: './add-library-form.css',
})
  type scheduleForDay = {
    dayOfWeek: string,
    openTime: string | null,
    closeTime: string | null,
    isClosed: boolean
  }

export class AddLibraryForm {
  fb = inject(FormBuilder);
  libraryService = inject(LibrariesService);

  days = [
    'Monday',
    'Tuesday',
    'Wednesday',
    'Thursday',
    'Friday',
    'Saturday',
    'Sunday'
  ];
  addLibraryForm = this.fb.group({
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

  onSubmit() {
    const request: LibraryRequest = {
      description: this.addLibraryForm.value.description!,
      coverImageUrl: this.addLibraryForm.value.coverImageUrl!,
      name: this.addLibraryForm.value.name!,
      address: this.addLibraryForm.value.address!,
      phone: this.addLibraryForm.value.phone!,
      email: this.addLibraryForm.value.email!,
      studyRooms: this.addLibraryForm.value.studyRooms!,
      computers: this.addLibraryForm.value.computers!,
      schedule: this.addLibraryForm.value.schedule!,
    };
    this.libraryService.createLibrary(request).subscribe();
  }


}
