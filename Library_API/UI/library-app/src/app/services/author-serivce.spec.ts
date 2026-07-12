import { TestBed } from '@angular/core/testing';

import { AuthorSerivce } from './author-serivce';

describe('AuthorSerivce', () => {
  let service: AuthorSerivce;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthorSerivce);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
