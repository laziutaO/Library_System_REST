import { TestBed } from '@angular/core/testing';
import { BooksFacadeService } from './books-facade-service';

describe('BooksFacadeService', () => {
  let service: BooksFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BooksFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
