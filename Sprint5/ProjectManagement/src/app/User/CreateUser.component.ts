import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceUserService } from '../User/ServiceUser.service';
import { NgForm } from '@angular/forms';
import { User } from '../User/User'

@Component({
  selector: 'app-createuser',
  templateUrl: './CreateUser.component.html',
  styleUrls: []
})
export class CreateUserComponent implements OnInit {
  constructor(private userService:ServiceUserService,private router:Router) {
  }

  ngOnInit(): void {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
  }

  onAddUser(userdata : NgForm)
  {
      this.userService.create(userdata.value).subscribe(res =>{ 
        console.log('User created!')
      this.router.navigate(['User']);
    });     
  }
}
