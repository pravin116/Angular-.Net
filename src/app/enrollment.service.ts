import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';
import { User } from './user';


@Injectable({
  providedIn: 'root'
})

export class EnrollmentService {

  private url = 'https://localhost:44317/';
  constructor(private http: HttpClient) {
}
   SearchDetail(result: User): Observable<User[]> {
     let NameUrl = `${this.url}Name/`;
     // tslint:disable-next-line: triple-equals
     if (result.FirstName != undefined) {
       NameUrl = `${NameUrl}${result.FirstName}/`;
     }
    // tslint:disable-next-line: triple-equals
     if (result.LastName != undefined) {
      NameUrl = `${NameUrl}${result.LastName}/`;
    }
     return this.http.get<User[]>(NameUrl);
  }

}
