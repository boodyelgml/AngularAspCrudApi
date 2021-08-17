import { HttpClient } from '@angular/common/http';
import { user } from './../model/user.model';
import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';


@Injectable()
export class UserService {

  public users: user[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }



}
