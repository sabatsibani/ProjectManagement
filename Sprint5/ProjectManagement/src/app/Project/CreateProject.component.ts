import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ServiceProjectService} from 'src/app/Project/ServiceProject.service';
import {NgForm} from '@angular/forms';
import {Project} from './Project';

@Component({
  selector: 'app-createproject',
  templateUrl: './CreateProject.component.html',
  styleUrls: []
})
export class CreateProjectComponent implements OnInit {

  constructor(private serviceProject: ServiceProjectService,private router: Router) { }

  ngOnInit(): void {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
  }
  onAddProject(projectdata: NgForm) {
    this.serviceProject.create(projectdata.value).subscribe(res => {
      console.log('Project created!')
      this.router.navigate(['Project']);
    });
  }
}