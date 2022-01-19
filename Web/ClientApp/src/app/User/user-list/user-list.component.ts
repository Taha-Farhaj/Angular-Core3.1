import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { UserService } from '../user.service';
import * as $ from 'jquery'
import { AddUserComponent } from '../add-user/add-user.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})



export class UserListComponent implements OnInit {

  displayedColumns: string[] = ['firstname', 'lastname', 'email', 'department', 'position', 'createdon', 'actions'];
  dataSource!: any;
  employeeFilterForm!: FormGroup;
  isLoading = false;
  totalRows = 0;
  pageSize = 25;
  currentPage = 0;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  @ViewChild(AddUserComponent) addUserComponent! :AddUserComponent;
  constructor(private userService: UserService, private formBuilder: FormBuilder) { }

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  ngAfterViewInit() {
    //this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {

    this.employeeFilterForm = this.formBuilder.group({
      firstName: [''],
      lastName: [''],
      email: [''],
      department: [''],
      positionId: [0],
      roleId: [0],
      siteId: [0],
    });

    this.bindData();
  }

  bindData() {
    this.isLoading = true;
    const pagingData = {
      PageId: this.currentPage,
      PageSize: this.pageSize
    }
    let employeeFilterForm = {
      firstName: this.employeeFilterForm.controls.firstName.value,
      lastName: this.employeeFilterForm.controls.lastName.value,
      email: this.employeeFilterForm.controls.email.value,
      positionId: this.employeeFilterForm.controls.positionId.value,
      roleId: this.employeeFilterForm.controls.roleId.value,
      siteId: this.employeeFilterForm.controls.siteId.value,
      department: this.employeeFilterForm.controls.department.value,
      PagingData: pagingData
    };


    this.userService.getAllUsers(employeeFilterForm).subscribe(
      data => {
        this.dataSource = new MatTableDataSource(data.item1);
        setTimeout(() => {
          this.paginator.pageIndex = this.currentPage;
          this.paginator.length = data.item2;
        });
        this.isLoading = false;
      },
      error => {
        console.log(error);
        this.isLoading = false;
      });
  }

  pageChanged(event: PageEvent) {
    console.log({ event });
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;
    this.bindData();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  onSubmit() {
    this.bindData();
  }

  onReset(){
    this.employeeFilterForm.reset();
    this.bindData();
  }

  onAdd(){
    $("#pnlAddUser").addClass("offcanvas-on")
  }

  editUser(element: any){
    this.addUserComponent.LoadData(element.id);
    $("#pnlAddUser").addClass("offcanvas-on")
  }

  deleteUser(element: any){
    
  }
}
