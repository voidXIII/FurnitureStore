import { IRoom } from "./room";

export interface IPagination {
    pageIndex: number
    pageSize: number
    count: number
    data: IRoom[]
  }