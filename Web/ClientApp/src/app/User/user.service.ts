import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserEndPoints } from './user.endpoints';
import { map } from 'rxjs/operators';
import { BaseService } from '../Service/base.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<any>{

  endPointControllerName = "ApplicationUser";
  constructor(httpClient: HttpClient,private http: HttpClient,private userEndPoints: UserEndPoints)
  { 
      super(
        httpClient,
        environment.dev_uri
        );
    }

  getAllUsers(customerFilterForm:any){
    return this.post(customerFilterForm, this.endPointControllerName + this.userEndPoints.getAllUsers)
    .pipe(map((data: any) => data));
  }

  saveUsers(_employeeForm:any){
    return this.post(_employeeForm, this.endPointControllerName + this.userEndPoints.saveUsers)
    .pipe(map((data: any) => data));
  }

}
