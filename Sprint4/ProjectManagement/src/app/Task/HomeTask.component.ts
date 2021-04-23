import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hometask',
  templateUrl: './HomeTask.component.html',
  styleUrls: []
})
export class HomeTaskComponent implements OnInit {

  public tasks = [] as any;

  constructor() {
    this.tasks = [
      { id: 1, projectid: 1, userid: 1, details: "Task 1", status: "status 1" },
      { id: 2, projectid: 2, userid: 2, details: "Task 2", status: "status 2" },
      { id: 3, projectid: 3, userid: 1, details: "Task 3", status: "status 2" },
      { id: 4, projectid: 2, userid: 1, details: "Task 4", status: "status 2" }
    ]
  }

  ngOnInit(): void {
  }

  trackBytaskCode(tasks: any): number{
    return tasks.id;
  }

}
