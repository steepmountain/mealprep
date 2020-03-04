export default class LocalStorageService {
    index = "";

    constructor(index) {
        this.index = index;
    }

    save(content) {
        localStorage.setItem(this.index, JSON.stringify(content));
    }

    load() {
        let item = localStorage.getItem(this.index);
        return item == null ? [] : JSON.parse(item);
    }
}