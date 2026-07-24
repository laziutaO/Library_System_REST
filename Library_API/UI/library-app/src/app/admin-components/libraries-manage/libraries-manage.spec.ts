import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrariesManage } from './libraries-manage';

describe('LibrariesManage', () => {
  let component: LibrariesManage;
  let fixture: ComponentFixture<LibrariesManage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LibrariesManage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LibrariesManage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
