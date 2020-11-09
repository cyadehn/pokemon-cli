using Xunit;
using System;

namespace PokemonCLI.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Constructor_CreateNewGameOnFalseContinuePlayerData()
        {
            PlayerData playerData = new PlayerData();
            var target = new MockGame(playerData);
            Assert.IsType<NewGameState>(target.GameState);
        }
        [Fact]
        public void Game_Constructor_CreateContinueStateOnTrueContinuePlayerData()
        {
            PlayerData playerData = new PlayerData();
            playerData.SavePlayerData();
            var target = new MockGame(playerData);
            Assert.IsType<ContinueState>(target.GameState);
        }
        [Theory]
        [ClassData(typeof(GameStateGenerator))]
        public void Game_TransitionTo_TransitionsToProvidedState(IState state)
        {
            PlayerData playerData = new PlayerData();
            var game = new MockGame(playerData);
            Type expected = state.GetType();
            game.TransitionTo(state);
            Assert.IsType(state.GetType(), game.GameState);
        }
        [Fact]
        public void Game_TransitionTo_AddsPlayerWhenPassed()
        {
            var playerData = new PlayerData();
            var game = new MockGame(playerData);
            var player = new PlayerCharacter(new MockUserInput());
            string expected = player.Name;
            game.TransitionTo(new ContinueState(), player);
            Assert.Contains(game.Players, p => p.Name == expected);
        }
    }
}