import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLibraryForm } from './edit-library-form';

describe('EditLibraryForm', () => {
  let component: EditLibraryForm;
  let fixture: ComponentFixture<EditLibraryForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditLibraryForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditLibraryForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
