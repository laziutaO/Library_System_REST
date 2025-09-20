import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibraryDetails } from './library-details';

describe('LibraryDetails', () => {
  let component: LibraryDetails;
  let fixture: ComponentFixture<LibraryDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LibraryDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LibraryDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
