import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BooksManage } from './books-manage';

describe('BooksManage', () => {
  let component: BooksManage;
  let fixture: ComponentFixture<BooksManage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BooksManage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BooksManage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
