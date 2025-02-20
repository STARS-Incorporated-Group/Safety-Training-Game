using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Backend.Scoring
{
    public class ScoreTracker
    {
        public BigInteger score { get; protected set; }
        private int _defaultScore;

        public ScoreTracker(int start = 10000)
        {
            this._defaultScore = start;
            this.score = new BigInteger(start);
        }

        public void Reset()
        {
            this.score = this._defaultScore;
        }

        public void Reset(int newDefaultValue)
        {
            this._defaultScore = newDefaultValue;
            this.score = newDefaultValue;
        }

        public void ScoreViolation(Violations violation)
        {
            this.score -= (int)violation;
        }

        public void ScoreReward(RewardLevels reward)
        {
            this.score += (int)reward;
        }
    }
}