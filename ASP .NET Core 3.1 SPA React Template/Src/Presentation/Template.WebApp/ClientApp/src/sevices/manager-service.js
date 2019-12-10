import authService from '../../src/components/api-authorization/AuthorizeService';

export const getAllManagers = () => {
    return new Promise((resolve, reject) => {
        authService
            .getUser()
            .then(user => {
                authService
                    .getAccessToken()
                    .then(token => {
                        fetch(`/api/Managers/GetAll`, {
                            method: 'GET',
                            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
                        })
                            .then(response => response.json())
                            .then(data => resolve(data))
                            .catch(err => reject(err))
                    })
            });
    });
}

export const getManager = (id) => {
    return new Promise((resolve, reject) => {
        authService
            .getAccessToken()
            .then(token => {
                fetch(`/api/Managers/Get/${id}`, {
                    method: 'GET',
                    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
                })
                    .then(response => response.json())
                    .then(data => resolve(data))
                    .catch(err => reject(err))
            })
    });
}

export const createManager = (payload) => {
    return new Promise((resolve, reject) => {
        authService
            .getAccessToken()
            .then(token => {
                fetch('/api/Managers/Create', {
                    method: 'POST',
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    },
                    body: JSON.stringify(payload)
                })
                    .then((res) => {
                        if (res.status === 400) {
                            resolve(res.json())
                        }
                        resolve();
                    })
                    .catch(err => reject(err));
            })
    });
}

export const updateManager = (payload) => {
    return new Promise((resolve, reject) => {
        authService
            .getAccessToken()
            .then(token => {
                fetch('/api/Managers/Update', {
                    method: 'PUT',
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    },
                    body: JSON.stringify(payload)
                })
                    .then((res) => {
                        if (res.status === 400) {
                            resolve(res.json())
                        }
                        resolve();
                    })
                    .catch(err => reject(err));
            })
    });
}

export const deleteManager = (id) => {
    return new Promise((resolve, reject) => {
        authService
            .getAccessToken()
            .then(token => {
                fetch(`/api/Managers/Delete/${id}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    }
                })
                    .then((res) => {
                        if (res.status === 400) {
                            resolve(res.json())
                        }
                        resolve();
                    })
                    .catch(err => reject(err));
            })
    });
}