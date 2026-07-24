import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLibraryForm } from './add-library-form';

describe('AddLibraryForm', () => {
  let component: AddLibraryForm;
  let fixture: ComponentFixture<AddLibraryForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddLibraryForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddLibraryForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
