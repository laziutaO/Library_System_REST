import { Injectable, signal, effect } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  public filterText = signal('');
  public filterLibrary = signal('');
  public filterBookAdmin = signal('');
  public filterAuthors = signal('');

   debouncedFilterText = toSignal(
    toObservable(this.filterText).pipe(
      debounceTime(200),        
      distinctUntilChanged(),     
      map(value => value.trim())  
    ),
    { initialValue: '' }
  );

  debouncedFilterLibrary = toSignal(
    toObservable(this.filterLibrary).pipe(
      debounceTime(200),        
      distinctUntilChanged(),     
      map(value => value.trim())  
    ),
    { initialValue: '' }
  );

  debouncedFilterBooks = toSignal(
    toObservable(this.filterBookAdmin).pipe(
      debounceTime(200),        
      distinctUntilChanged(),     
      map(value => value.trim())  
    ),
    { initialValue: '' }
  );

  debouncedFilterAuthors = toSignal(
    toObservable(this.filterAuthors).pipe(
      debounceTime(100),
      distinctUntilChanged(),
      map(value => value.trim())
    ),
    { initialValue: '' }  
    );
  
}
