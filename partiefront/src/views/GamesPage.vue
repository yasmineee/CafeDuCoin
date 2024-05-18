<template>
    <div>
        <h1>Liste des Jeux</h1>
        <ul>
            <li v-for="game in games" :key="game.id">
                {{ game.name }} - {{ game.currentState }}
                <button @click="goToGameHistory(game.id)">View History</button>
            </li>
        </ul>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'GameList',
        data() {
            return {
                games: []
            };
        },
        created() {
            this.fetchGames();
        },
        methods: {
            async fetchGames() {
                try {
                    const response = await axios.get('http://localhost:5000/api/game');
                    this.games = response.data;
                } catch (error) {
                    console.error('Erreur lors de la récupération des jeux:', error);
                }
            },
            goToGameHistory(gameId) {
                this.$router.push({ name: 'GameHistory', params: { id: gameId } });
            }
        }
    };
</script>

<style scoped>
    h1 {
        font-size: 2em;
        margin-bottom: 1em;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        padding: 0.5em 0;
    }
</style>