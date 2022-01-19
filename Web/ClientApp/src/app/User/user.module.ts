import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserListComponent } from './user-list/user-list.component';
import { MaterialModule } from '../Shared/material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../Shared/shared/shared.module';
import { RouterModule } from '@angular/router';
import { AddUserComponent } from './add-user/add-user.component';


@NgModule({
  declarations: [ UserListComponent, AddUserComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    MaterialModule,
    HttpClientModule,
    SharedModule,
    RouterModule
  ],
  exports: [],
  
})
export class UserModule { }
