import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homescreen',
  templateUrl: './HomeScreen.component.html',
  styleUrls: []
})
export class HomeScreenComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login'])
    }
  }

}
