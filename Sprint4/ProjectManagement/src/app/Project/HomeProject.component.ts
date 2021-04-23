import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homeproject',
  templateUrl: './HomeProject.component.html',
  styleUrls: []
})
export class HomeProjectComponent implements OnInit {

  public projects = [] as any;

  constructor() {
    this.projects = [
      { id: 1, projectname: "Project 1", details: "This is project 1" },
      { id: 2, projectname: "Project 2", details: "This is project 2" },
      { id: 3, projectname: "Project 3", details: "This is project 3" },
      { id: 4, projectname: "Project 4", details: "This is project 4" }
    ]
  }

  ngOnInit(): void {
  }

  trackByprojectsCode(projects: any): number{
    return projects.id;
  }

}
