import React from 'react';
import './LoyaltyPage.css';
import {Header} from "../../components";
import {Footer} from "../../components";
import {FOOTER_IMAGE} from "../../resources";

export function LoyaltyPage() {
    return (
        <div className="loyalty-page">
            <Header/>

            <div className="loyalty-page__content">
                <h1>Програма лояльності</h1>

                <img
                    src={FOOTER_IMAGE.LOYALTY}
                    alt="Програма лояльності"
                    className="loyalty-image"
                />

                <p>
                    Наша програма лояльності - це спеціальна пропозиція для наших постійних
                    клієнтів. Долучайтеся до нашої програми та отримуйте регулярні
                    знижки, бонуси та інші приємні бонуси.
                </p>
                <h2>Переваги участі в програмі:</h2>
                <ul>
                    <li>Знижки на всі товари</li>
                    <li>Бонуси за кожну покупку</li>
                    <li>Спеціальні пропозиції для учасників</li>
                </ul>
                <h2>Як отримати бонуси:</h2>
                <ol>
                    <li>Зареєструйтеся в програмі лояльності</li>
                    <li>Здійснюйте покупки та отримуйте бонуси за кожну покупку</li>
                    <li>Обмінюйте бонуси на знижки та подарунки</li>
                </ol>
                <h2>Бонусні правила:</h2>
                <ul>
                    <li>За кожні 100 грн покупки отримайте 5 бонусів</li>
                    <li>Бонуси можна використовувати на наступних покупках</li>
                    <li>Спеціальні бонуси на дні народження</li>
                </ul>
            </div>
            <p className="loyalty-page__content__lastP">
                Приєднуйтесь до нашої програми лояльності і насолоджуйтеся
                ексклюзивними перевагами від нашого магазину🤗
            </p>

            <Footer />
        </div>
    );
}