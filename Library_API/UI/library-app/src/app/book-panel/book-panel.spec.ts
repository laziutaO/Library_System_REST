import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookPanel } from './book-panel';

describe('BookPanel', () => {
  let component: BookPanel;
  let fixture: ComponentFixture<BookPanel>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookPanel]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookPanel);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
