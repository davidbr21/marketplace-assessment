export class PageModel<T> {
    items: Array<T>;
    nextPageIndex: number;
    pageCount: number;
    pageIndex: number;
    previousPageIndex: number;

    /**
     * @description Make sure this is always an odd number
     */
    private maxPages: number = 9;

    constructor(items: Array<T>, pageIndex: number, pageCount: number){
        this.items = items;
        this.pageIndex = pageIndex;
        this.nextPageIndex = 1;
        this.previousPageIndex = null;
        this.pageCount = pageCount;
    }

    /**
     * @description Gets at most three next page indexes (only the ones that exists).
     * @returns The next page index from the current index
     */
    getNextPageIndexes(): number {
        if(this.pageIndex <= Math.floor(this.maxPages / 2)) return this.maxPages // Ensures to always show maxPages (7)
        return (this.pageIndex + Math.floor(this.maxPages / 2) >= this.pageCount) ? this.pageCount : this.pageIndex + Math.ceil(this.maxPages / 2)
    }

    /**
     * @description Gets at most three next previous indexes (only the ones that exists).
     * @returns The previous page index from the current index
     */
    getPreviousPageIndexes(): number {
        if(this.pageIndex + Math.floor(this.maxPages / 2) >= this.pageCount) return this.pageCount - this.maxPages // Ensures to always show maxPages (7)
        return (this.pageIndex <= Math.floor(this.maxPages / 2)) ? 0 : this.pageIndex - Math.floor(this.maxPages / 2)
    }
}
