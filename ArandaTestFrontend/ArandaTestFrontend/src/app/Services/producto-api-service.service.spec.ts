import { TestBed } from '@angular/core/testing';

import { ProductoApiServiceService } from './producto-api-service.service';

describe('ProductoApiServiceService', () => {
  let service: ProductoApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductoApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
