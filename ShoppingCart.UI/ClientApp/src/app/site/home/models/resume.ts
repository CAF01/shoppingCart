export class Resume {
    constructor(
      article: string,
      count: number,
      total: number) {
      this.article = article;
      this.count = count;
      this.total = total;
    }
  
    article: string;
    count: number;
    total: number;
  }