import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as $ from 'jquery'
import { ToastrService } from 'ngx-toastr';
import { ConstantService } from 'src/app/Service/constant.service';
import { UserEndPoints } from '../user.endpoints';
import { UserService } from '../user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  isLoading = false;
  employeeForm!: FormGroup;
  constructor(private userService: UserService, private formBuilder: FormBuilder, private toastr: ToastrService, public constantService: ConstantService,private userEndPoints: UserEndPoints) { }

  ngOnInit(): void {
    this.employeeForm = this.formBuilder.group({
      isActive: [''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
      roleIds: ['', Validators.required],
      siteIds: ['', Validators.required],
      dateOfBirth: [''],
      gender: [''],
      mobilePhone: [''],
      city: [''],
      positionId: [0, Validators.required],
      departmentId: [0, Validators.required],
      extensionNumber: [''],
      district: [''],
      skypeName: [''],
      hiringDate: [''],
      signature: [''],
      secondaryEmail: ['']
    });
  }

  get f() { return this.employeeForm.controls; }

  LoadData(id: number) {
    debugger;
    if (id === 0) {
      this.employeeForm.reset();
    }
    else {
      this.userService.get(id, this.userService.endPointControllerName + this.userEndPoints.getUsers).subscribe(
        data => {
          debugger;
          this.SetValue(data);
          this.isLoading = false;
        },
        error => {
          console.log(error);
          this.isLoading = false;
          this.toastr.error(error.error.message)
        });
    }
  }

  SetValue(data: any){
    let values: any;
    values = {};
    Object.keys(data).forEach(key => {
      values[key.toLowerCase()] = data[key];
    });
    Object.keys(this.employeeForm.controls).forEach(key => {
      if (values[key.toLowerCase()] !== undefined) {
        this.employeeForm.get(key)?.patchValue(values[key.toLowerCase()]);
      }
    });
  }

  UpdateData() {
    if(this.employeeForm.invalid){
      this.constantService.markFormGroupTouched(this.employeeForm);
      return;
    }
    this.isLoading = true;
    let _employeeForm = {
      firstName: this.employeeForm.controls.firstName.value,
      lastName: this.employeeForm.controls.lastName.value,
      userName: this.employeeForm.controls.userName.value,
      email: this.employeeForm.controls.email.value,
      positionId: this.employeeForm.controls.positionId.value,
      departmentId: this.employeeForm.controls.departmentId.value,
      password: this.employeeForm.controls.password.value,
      roleIds: this.employeeForm.controls.roleIds.value,
      siteIds: this.employeeForm.controls.siteIds.value,
      dateOfBirth: this.employeeForm.controls.dateOfBirth.value,
      gender: this.employeeForm.controls.gender.value,
      mobilePhone: this.employeeForm.controls.mobilePhone.value,
      city: this.employeeForm.controls.city.value,
      extensionNumber: this.employeeForm.controls.extensionNumber.value,
      district: this.employeeForm.controls.district.value,
      skypeName: this.employeeForm.controls.skypeName.value,
      hiringDate: this.employeeForm.controls.hiringDate.value,
      signature: this.employeeForm.controls.signature.value,
      secondaryEmail: this.employeeForm.controls.secondaryEmail.value,
      isActive: this.employeeForm.controls.isActive.value,
    };



    this.userService.saveUsers(_employeeForm).subscribe(
      data => {
        this.isLoading = false;
        this.toastr.success("Employee saved successfully");
      },
      error => {
        console.log(error);
        this.isLoading = false;
        this.toastr.error(error.error.message)
      });
  }

  closePanel() {
    $("#pnlAddUser").removeClass("offcanvas-on")
  }

}
