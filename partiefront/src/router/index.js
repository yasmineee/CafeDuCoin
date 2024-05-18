import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../views/HomePage.vue';
import GamesPage from '../views/GamesPage.vue';
import LoginPage from '../views/LoginPage.vue';
import GameHistoryPage from '../views/GameHistoryPage.vue';

const routes = [
    {
        path: '/',
        name: 'Home',
        component: HomePage
    },
    {
        path: '/login',
        name: 'Login',
        component: LoginPage
    },
    {
        path: '/games',
        name: 'Games',
        component: GamesPage
    },
    {
        path: '/games/:id/history',
        name: 'GameHistory',
        component: GameHistoryPage,
        props: true
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;