import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../User/User'
import { CommonServiceService } from '../CommonService.service'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceUserService extends CommonServiceService<User>{

  updateUserCollection! : User;
  
  constructor(protected http :HttpClient) {
    super(http,'User');
   }

   login(body: User): Observable<User> {
     console.log(this.apiUrl);
    return this.http.post<User>(this.apiUrl+'/Login', body);
  }
}
