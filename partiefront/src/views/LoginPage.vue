<template>
    <div>
        <h1>Login</h1>
        <form @submit.prevent="login">
            <div>
                <label for="username">Username:</label>
                <input type="text" id="username" v-model="username">
            </div>
            <div>
                <label for="password">Password:</label>
                <input type="password" id="password" v-model="password">
            </div>
            <button type="submit">Login</button>
        </form>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'LoginPage',
        data() {
            return {
                username: '',
                password: ''
            };
        },
        methods: {
            async login() {
                try {
                    const response = await axios.post('http://localhost:5000/api/auth/login', {
                        login: this.username,
                        password: this.password
                    });
                    if (response.status === 200) {
                        // Assume you store the JWT token in local storage
                        localStorage.setItem('token', response.data.token);
                        // Redirect to games page
                        this.$router.push('/games');
                    }
                } catch (error) {
                    console.error('Authentication error:', error.message);
                    if (error.response) {
                        console.error('Response status:', error.response.status);
                        console.error('Response data:', error.response.data);
                    }
                }
            }
        }
    };
</script>

