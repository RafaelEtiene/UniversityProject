import { Component, OnInit, inject } from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';
import { StudentsService } from 'src/api/students.service';
import { StudentsAnalyticsViewModel } from 'src/viewmodel/StudentsAnalyticsInfoViewModel';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private studentsService: StudentsService){}

  ngOnInit(): void {
      this.GetStudentsAnalyticsInfo();
  }

  studentsInfo: StudentsAnalyticsViewModel = null!;

  public GetStudentsAnalyticsInfo() {
    this.studentsService.GetStudentsAnalyticsInfo()
    .subscribe(r => {
      this.studentsInfo = r;
    })
  }

}
