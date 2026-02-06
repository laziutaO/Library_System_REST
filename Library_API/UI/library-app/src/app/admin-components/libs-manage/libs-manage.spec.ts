import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibsManage } from './libs-manage';

describe('LibsManage', () => {
  let component: LibsManage;
  let fixture: ComponentFixture<LibsManage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LibsManage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LibsManage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
