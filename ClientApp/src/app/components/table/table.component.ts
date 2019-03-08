import { Component, Directive, EventEmitter, Input, Output, QueryList, ViewChildren } from '@angular/core';
import { CurrentBranchInfo } from '../../models/CurrentBranchInfoModel';
import { BranchService } from '../../apiServices/branchApi.service';

@Component({
  selector: 'ngbd-table',
  templateUrl: './table.html'
})
export class NgbdTable {

  constructor(private branchService: BranchService
  ) {

  }

  ngOnInit() {
    this.branchService.getCurrentBranchesInfo()
      .subscribe((data: CurrentBranchInfo[]) => this.branches = data);
  }

  branches: CurrentBranchInfo[];

}
