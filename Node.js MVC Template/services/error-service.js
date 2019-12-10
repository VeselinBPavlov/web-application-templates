module.exports = {
    handleError: (res, error, page) => {
        console.log(error);
        res.locals.globalError = error;
        res.render(page);
    }
}