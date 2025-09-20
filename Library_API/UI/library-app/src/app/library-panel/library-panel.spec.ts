import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibraryPanel } from './library-panel';

describe('LibraryPanel', () => {
  let component: LibraryPanel;
  let fixture: ComponentFixture<LibraryPanel>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LibraryPanel]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LibraryPanel);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
