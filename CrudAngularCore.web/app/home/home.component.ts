import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent {

  public users: user[];
  public showForm = true;
  public formdata: FormGroup;



  public FormEditMode: boolean = true;

  public formUser = new user();




  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  // fetch all users
  ngOnInit() {
    this.getAllUsers();
    this.init_Form()
  }

  public init_Form() {

    // validate the form

    this.formdata = new FormGroup({
      id: new FormControl(),
      userName: new FormControl(),
      userPhone: new FormControl(),
      userMail: new FormControl()
    });



  }

  // on sumbit form
  onClickSubmit() {
    if (!this.FormEditMode) {
      this.createUser(this.formUser);
    } else {
      this.updateUser(this.formUser);
    }
  }

  // get all users
  getAllUsers() {
    this.http.get<user[]>(this.baseUrl + 'User').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }

  // create user
  createUser(user: user) {
    user.id = 0;
    const newUser = JSON.stringify(user);
    const headers = { 'content-type': 'application/json' }

    this.http.post(this.baseUrl + "User/", newUser, { 'headers': headers }).subscribe(result => {
      this.users.push(user);
      this.getAllUsers();
    }, error => console.error(error));

  }

  // update user
  updateUser(user: user) {

    const newUser = JSON.stringify(user);
    const headers = { 'content-type': 'application/json' }

    this.http.put(this.baseUrl + `User/`, newUser, { 'headers': headers }).subscribe(result => {
      this.getAllUsers();
    }, error => console.error(error));

  }

  // delete user
  deleteUser(id: number, index: number) {
    console.log(id, index)
    this.http.delete(this.baseUrl + 'User/' + id).subscribe(result => {
      this.users.splice(index, 1);
      this.getAllUsers();

    }, error => console.error(error));
  }

  // show & hide form
  switchFormVisibility() {
    this.showForm = !this.showForm
  }

  SwitchFormToEdit(id, index) {

    this.formUser = new user();
    // asign to the form
    this.showForm = true;
    // edit mode ON
    this.FormEditMode = true;
    //this.formUser = this.users[index];
    Object.assign(this.formUser, this.users[index])

  }

  SwitchFormToAdd() {

    this.formUser.id = 0;
    // Edit mode OFF
    this.FormEditMode = false;

  }

}

class user {
  id?: number ;
  userName: string;
  userPhone: number;
  userMail: string;
}
