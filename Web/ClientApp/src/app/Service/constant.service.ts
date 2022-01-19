import { HttpBackend, HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
//import { AuthenticationService } from '@app/core/services/authentication.service';
// import { FileSaverService } from 'ngx-filesaver';
import * as moment from 'moment';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ConstantService {

  login() {
    this.router.navigate(['/login']);
  }
    
  public ckConfig = {
    toolbar: {
      items: [ 'heading', '|',  'fontfamily', 'fontsize', '|', 'alignment', '|',
          'fontColor', 'fontBackgroundColor', '|',
          'bold', 'italic', 'strikethrough', 'underline', 'subscript', 'superscript', '|',
          'link', '|',
          'custombutton',
          'outdent', 'indent', '|',
          'bulletedList', 'numberedList', 'todoList', '|',
          'code', 'codeBlock', '|',
          'insertTable', '|',
          'blockQuote', '|',
          'undo', 'redo'
      ],
    
  }
  };

  public disableConfig = {
    isReadOnly : true,
    toolbar: {
      items: [  ],
    
  }
  };
  
  defaultPage: number;
  defaultItemPerPage: number;
  constructor(
    private httpClient: HttpClient,
    private httpBackend: HttpBackend,
    private ngbModal: NgbModal,
    private toastrService: ToastrService,
    private router: Router
  ) {
    this.defaultPage = 1;
    this.defaultItemPerPage = 20;
  }

  download(url:string, fromRemote = true) {
    const header = new HttpHeaders()
      .append('Content-Type', 'application/json')
      .append('Access-Control-Allow-Headers', 'Content-Type')
      .append('Access-Control-Allow-Methods', 'GET')
      .append('Access-Control-Allow-Origin', '*');
    this.httpClient = new HttpClient(this.httpBackend);
    const fileName = `save.png`;
    if (fromRemote) {
      this.httpClient.get(url, {
        observe: 'response',
        responseType: 'blob',
        headers: header
      }).subscribe(res => {
        //this.fileSaverService.save(res.body, fileName);
      });
      return;
    }
    //const fileType = this.fileSaverService.genType(fileName);
  }


  detachObject(model:any) {
    return JSON.parse(JSON.stringify(model));
  }

  addBodyBlur() {
    const body = document.getElementsByTagName('BODY')[0];
    // body.classList.add('filter-back');
    body.classList.add('overlay');
  }

  removeBodyBlur() {
    const body = document.getElementsByTagName('BODY')[0];
    // body.classList.remove('filter-back');
    body.classList.remove('overlay');
  }



//   momentDiffDate(date1: Date, date2: Date) {
//     const starts = moment(date1);
//     const ends = moment(date2);
//     const duration = moment.duration(ends.diff(starts));
//     const diff = moment.preciseDiff(starts, ends, true);
//     // var diffHuman = moment.preciseDiff(starts, ends);
//     const year = diff.years ? diff.years + ' years ' : '';
//     const months = diff.months ? diff.months + ' months ' : '';
//     const days = diff.days ? diff.days + ' days ' : '';
//     const hours = diff.hours ? diff.hours + ' hours ' : '';
//     const minutes = diff.minutes ? diff.minutes + ' minutes' : '';
//     const diffHuman =  year + months + days + hours + minutes;
//     if(diff.years < 1 && diff.months < 1 && diff.days < 1 && diff.hours < 1 && diff.minutes < 1){
//       return "Now";
//     }
//     else{
//       return diffHuman;
//     }
//   }

  dateDiff(startingDate: string, endingDate: string) {
    let startDate = new Date(new Date(startingDate).toISOString().substr(0, 10));
    if (!endingDate) {
      endingDate = new Date().toISOString().substr(0, 10);    // need date in YYYY-MM-DD format
    }
    let endDate = new Date(endingDate);
    if (startDate > endDate) {
      const swap = startDate;
      startDate = endDate;
      endDate = swap;
    }
    const startYear = startDate.getFullYear();
    const february = (startYear % 4 === 0 && startYear % 100 !== 0) || startYear % 400 === 0 ? 29 : 28;
    const daysInMonth = [31, february, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    let yearDiff = endDate.getFullYear() - startYear;
    let monthDiff = endDate.getMonth() - startDate.getMonth();
    if (monthDiff < 0) {
      yearDiff--;
      monthDiff += 12;
    }
    let dayDiff = endDate.getDate() - startDate.getDate();
    if (dayDiff < 0) {
      if (monthDiff > 0) {
        monthDiff--;
      } else {
        yearDiff--;
        monthDiff = 11;
      }
      dayDiff += daysInMonth[startDate.getMonth()];
    }

    let daysLabel = ' days, ';
    if (dayDiff <= 1) {
      daysLabel = ' day, ';
    }

    let monthsLabel = ' months, ';
    if (dayDiff <= 1) {
      monthsLabel = ' month, ';
    }


    return monthDiff + ' ' + monthsLabel + ' ' + dayDiff + ' ' + daysLabel;
  }




//   UtcDateTime(dateTime: any) {
//     dateTime = dateTime.replace ? dateTime.replace('Z', '') : dateTime;
//     const timezone = this.authenticationService.timeZone;
//     const hrs = timezone;
//     const dt = new Date(dateTime);
//     dt.setTime(dt.getTime() + (hrs*60*60*1000));
//     return dt;
//   }

//   convertDate(val: any){
//     const date = new Date(val);
//     return ((date.getMonth() > 8) ? (date.getMonth() + 1) : ('0' + (date.getMonth() + 1))) + '/' + ((date.getDate() > 9) ? date.getDate() : ('0' + date.getDate())) + '/' + date.getFullYear();
//   }

//   getTodayDate(): string {
//     const timezone = this.authenticationService.timeZone;
//     const date = new Date();
//     date.setHours(0, 0, 0, 0);
//     return new Date(date.getTime() - (timezone * 60 * 60 * 1000) - (date.getTimezoneOffset() * 60000)).toISOString();
//   }

//   setCurrentDate(d:any) {
//     const timezone = this.authenticationService.timeZone;
//     const currentdate = new Date(d);
//     return new Date(currentdate.getTime() - (timezone * 60 * 60 * 1000) - (currentdate.getTimezoneOffset() * 60000)).toISOString();
//   }

//   getCurrentDate() {
//     const timezone = this.authenticationService.timeZone;
//     const currentdate = new Date();
//     const currDate = (currentdate.getMonth() + 1) + "/"
//       + currentdate.getDate() + "/"
//       + currentdate.getFullYear()

//     const date = new Date();
//     return new Date(date.getTime() - (timezone * 60 * 60 * 1000) - (date.getTimezoneOffset() * 60000)).toISOString();
//   }

//   getFromDate(val: any) {
//     const timezone = this.authenticationService.timeZone;
//     const currentdate = new Date();
//     const fromDateObj = new Date(currentdate.getFullYear(), currentdate.getMonth(), currentdate.getDate() + +val);
//     const fromDate = (fromDateObj.getMonth() + 1) + "/"
//       + fromDateObj.getDate() + "/"
//       + fromDateObj.getFullYear()
//     const time = this.sharedService.getCustomTime(currentdate);
//     const date = new Date(fromDate + ' ' + time);
//     return new Date(date.getTime() - (timezone * 60 * 60 * 1000) - (date.getTimezoneOffset() * 60000)).toISOString();
//   }


  getTodayNumber() {
    const days = [1, 2, 3, 4, 5, 6, 7];
    const d = new Date();
    return days[d.getDay()];
  }

  setPostValue(schemeForm: any): any {
    let body: any;
    body = {};
    Object.keys(schemeForm.controls).forEach(key => {
      body[key] = schemeForm.controls[key].value;
    });
    return body;
  }

  getFileName(FileUrl: any){
    const fileName = FileUrl.split('/').pop().substring(36);
    return fileName.replace(/%20/g, ' ');;
  }

  getFileNameWithSpace(fileName :any){
    return fileName.replace(/%20/g, ' ');;
  }

  
//   accessDeniedModal(msg :any){
//     const modalRef = this.ngbModal.open(AccessDeniedComponent, {
//       size: 'md',
//       windowClass: 'gateway-modal',
//       backdrop: true,
//       keyboard: false,
//     });
//     modalRef.componentInstance.message = msg;
//     modalRef.result.then((result: any) => {
//     }).catch((error: any) => {
//       console.log(error);
//     });
//   }

  
//   tabsPermission(key: any, isPopup :any) {
//     const val = this.rolesArray.find(x => x.key === key);
//     if (val && val.value.includes(this.authenticationService.RoleId)) {
//       return true;
//     }
//     if (isPopup) {
//       this.accessDeniedModal("");
//     }
//     return false;
//   }


//   rolesArray = [
//     {
//       key: TabsEnum.forEveryone,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin
//       ]
//     },
//     {
//       key: TabsEnum.assignedTechnician,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin,
//         UserRolesEnum.operator,
//         UserRolesEnum.leadTechnician,
//         UserRolesEnum.technician,
//       ]
//     },
//     {
//       key: SettingsTab.settings,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin,
//         UserRolesEnum.operator,
//         UserRolesEnum.leadTechnician,
//         UserRolesEnum.technician,
//         UserRolesEnum.user,
//       ]
//     }, {
//       key: SettingsTab.notification,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin,
//         UserRolesEnum.operator,
//         UserRolesEnum.technician,
//         UserRolesEnum.leadTechnician,
//         UserRolesEnum.user,
//       ]
//     },
//     {
//       key: SettingsTab.billing,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin,
//       ]
//     }, {
//       key: SettingsTab.companyaccount,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin,
//       ]
//     },
//     {
//       key: TabsEnum.viewUserShift,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin,
//         UserRolesEnum.leadTechnician,
//       ]
//     },
//     {
//       key: TabsEnum.sendInvitation,
//       value: [
//         UserRolesEnum.admin,
//         UserRolesEnum.superAdmin,
//         UserRolesEnum.leadTechnician,
//       ]
//     },
//   ];

  /**
   * Check file is image or not
   * @param filePath - File Path to get file extention
   */
  validatePath(path: string) {
    const _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
    var sFileName = path;
    if (sFileName.length > 0) {
      var blnValid = false;
      for (var j = 0; j < _validFileExtensions.length; j++) {
        var sCurExtension = _validFileExtensions[j];
        if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
          blnValid = true;
          break;
        }
      }
      if (!blnValid) {
        this.toastrService.info("Sorry, " + sFileName + " is invalid, allowed extensions are: " + _validFileExtensions.join(", "), "Info");
        return false;
      }
    }
    return true;
  }

  /**
   * Marks all controls in a form group as touched
   * @param formGroup - The form group to touch
   */
   public markFormGroupTouched(formGroup: FormGroup) {
    (<any>Object).values(formGroup.controls).forEach((control:any) => {
      control.markAsTouched();

      if (control.controls) {
        this.markFormGroupTouched(control);
      }
    });
  }
}


// export enum SecurityMethodEnum {
//   mobile = 1,
//   email = 2,
//   both = 3,
  
// }


// export enum TabsEnum {
//   forEveryone = 'forEveryone',
//   assignedTechnician = 'assignedTechnician',
//   companyAccount = 'companyAccount',
//   billing = 'billing',
//   viewUserShift = 'viewUserShift',
//   sendInvitation = 'sendInvitation',
  
// }


// export enum BillingPlanEnum {
//   enterprise = 'enterprise plan',
//   premium = 'premium plan',
//   standard = 'standard plan',
// }


// export enum SensorStatusEnum {
//   warning = 'Warning',
//   critical = 'Critical',
//   inProgress = 'In Progress',
//   stable = 'Stable'
// }


// export enum SensorStatusIdEnum {
//   stable = 1,
// }

// export enum SensorStatusNameEnum {
//   stable = 'Stable',
// }



// export enum SensorDataTypeNameEnum {
//   digital = 'digital',
//   analog = 'analog',
//   modbus = 'modbus'
// }

// export enum SensorDataTypeIDEnum {
//   digital = 1,
//   analog = 2,
//   modbus = 3,
// }

// export enum SettingsTab {
//   settings = 'settings',
//   notification = 'notification',
//   companyaccount = 'companyaccount',
//   billing = 'billing',
//   MFA = 'mfa',
// }

// export enum UserListTabEnum {
//   deactivateUser = 'deactivate',
//   bulkDeactivateUser = 'Deactivate User(s)',
//   activateUser = 'activate',
//   deleteUser = 'deleteUser',
// }


// export enum UserRolesEnum {
//   totalUsers = '57c1fe0a-44b6-4ac2-8438-e3acbd925277',
//   superAdmin = '93f204a2-747d-4f00-9a8f-a27043565ba8',
//   admin = '38d42a6f-e91e-4498-b1b3-7ca8da85e8ce',
//   user = '8715e1f3-d0d0-4e4b-b458-06b9aa378103',
//   operator = 'af018ca4-0ba4-4bed-aef8-ac8a02a2dc56',
//   technician = '93986ea8-f64d-4f30-9393-fa05f1a6fc11',
//   deactivatedUser = '0de47a42-86ff-49f5-a688-b7916122c02e',
//   invitePending = 'ad0c43a3-7dde-4e10-89d0-f4caea6fc7e8',
//   leadTechnician = '27f1ce7c-1ca9-44a2-8af7-7dc027e5535b',
// }

// export enum UserRolesEnumById {
//   '57c1fe0a-44b6-4ac2-8438-e3acbd925277' = 'totalUsers',
//   '93f204a2-747d-4f00-9a8f-a27043565ba8' = 'superAdmin',
//   '38d42a6f-e91e-4498-b1b3-7ca8da85e8ce' = 'admin',
//   '8715e1f3-d0d0-4e4b-b458-06b9aa378103' = 'user',
//   'af018ca4-0ba4-4bed-aef8-ac8a02a2dc56' = 'operator',
//   '93986ea8-f64d-4f30-9393-fa05f1a6fc11' = 'technician',
//   '0de47a42-86ff-49f5-a688-b7916122c02e' = 'deactivatedUser',
//   'ad0c43a3-7dde-4e10-89d0-f4caea6fc7e8' = 'invitePending',
//   '27f1ce7c-1ca9-44a2-8af7-7dc027e5535b' = 'leadTechnician',
// }

// export enum UserRolesEnumDD {
//   '57c1fe0a-44b6-4ac2-8438-e3acbd925277' = 'Total Users',
//   '93f204a2-747d-4f00-9a8f-a27043565ba8' = 'Account Owner',
//   '38d42a6f-e91e-4498-b1b3-7ca8da85e8ce' = 'Admin',
//   '8715e1f3-d0d0-4e4b-b458-06b9aa378103' = 'View Only',
//   'af018ca4-0ba4-4bed-aef8-ac8a02a2dc56' = 'Operator',
//   '93986ea8-f64d-4f30-9393-fa05f1a6fc11' = 'Technician',
//   '0de47a42-86ff-49f5-a688-b7916122c02e' = 'Deactivated User',
//   'ad0c43a3-7dde-4e10-89d0-f4caea6fc7e8' = 'Invite Pending',
//   '27f1ce7c-1ca9-44a2-8af7-7dc027e5535b' = 'Lead Technician',
// }

// export enum UserRolesEnumASR {
//   '93f204a2-747d-4f00-9a8f-a27043565ba8' = 'Account Owner',
//   '38d42a6f-e91e-4498-b1b3-7ca8da85e8ce' = 'Admin',
//   '8715e1f3-d0d0-4e4b-b458-06b9aa378103' = 'View Only',
//   'af018ca4-0ba4-4bed-aef8-ac8a02a2dc56' = 'Operator',
//   '93986ea8-f64d-4f30-9393-fa05f1a6fc11' = 'Technician',
//   '27f1ce7c-1ca9-44a2-8af7-7dc027e5535b' = 'Lead Technician',
// }

// export enum GetewayTypesEnum{
//   Cellular = 1,
//   Wifi = 2
// }

// export enum ImageFolderEnum{
//   Sensor = 'SensorImages',
//   Asset = 'AssetImages'
// }

// export enum localStarageParms {
//   _registerUser = '_registerUser'
// }

// export enum encryptionParms {
//   _registerUser_en = '_registerUser_en'
// }

// export enum GatewayTypes {
//   cellular = '1',
//   wifi = '2',
// }
