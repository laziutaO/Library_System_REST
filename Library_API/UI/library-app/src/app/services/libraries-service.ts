import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LibraryData } from '../interfaces/library-data';
import { LibrariesResponce } from '../interfaces/libraries-responce';
import { map } from 'rxjs/operators';
import { LibraryResponce } from '../interfaces/library-responce';

@Injectable({
  providedIn: 'root'
})
export class LibrariesService {
  private apiUrl = "https://localhost:7103/api/Libraries";
  constructor(private http: HttpClient){}

  getAllLibraries(): Observable<LibraryData[]>{
    return this.http.get<LibrariesResponce>(this.apiUrl).pipe(map(libraries => libraries['libraries']));
  }

  getLibraryById(id: string): Observable<LibraryData>{
    return this.http.get<LibraryResponce>(`${this.apiUrl}/${id}`).pipe(map(library=> library['library']));
  }

  deleteLibrary(id: string):Observable<any>{
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
