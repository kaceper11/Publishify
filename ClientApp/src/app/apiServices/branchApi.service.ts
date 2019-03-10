import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CurrentBranchInfo } from '../models/CurrentBranchInfoModel';
import { PublishHistory } from '../models/PublishHistoryModel';


@Injectable()
export class BranchService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44321/api/Branch';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getCurrentBranchesInfo() {
    return this.http.get<CurrentBranchInfo[]>(this.accessPointUrl + '/getCurrentBranchesInfo', { headers: this.headers });
  }

  public getPublishHistory(branchId: number) {
    return this.http.get<PublishHistory[]>(this.accessPointUrl + '/getPublishHistory/' + branchId, { headers: this.headers });
  }


}
